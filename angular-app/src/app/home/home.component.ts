import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '../_models';
import { UserService } from '../_services';

import { AuthenticationService } from '../_services';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent implements OnInit {
    users: User[] = [];
    curUser: User;

    constructor(private userService: UserService,
        private authenticationService: AuthenticationService) { }

    ngOnInit() {
        this.userService.getAll().pipe(first()).subscribe(users => {
            this.users = users;
        });

        this.curUser = this.userService.getCurrent();
    }

    logOut() {
        this.authenticationService.logout();
    }
}
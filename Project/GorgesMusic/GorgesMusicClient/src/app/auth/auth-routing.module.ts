import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { LogoutComponent } from "./logout/logout.component";
import { RegisterComponent } from "./register/register.component";

const routes : Routes = [
    {
        path : 'login',
        component : LoginComponent,
        data: {
            title : 'Login',
            loginRequired : false
             }   
        },
        {
            path : 'register',
            component : RegisterComponent,
            // data: {
            //     title : 'Register',
            //     loginRequired : false
            // },
        },
        {
            path : 'logout',
            component : LogoutComponent,
            data: {
                title : 'Logout',
                loginRequired : true
            },
        }
];

export const AuthRoutingModule = RouterModule.forChild(routes);
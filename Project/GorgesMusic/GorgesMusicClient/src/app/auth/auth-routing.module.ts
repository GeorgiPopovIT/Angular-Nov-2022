import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { LogoutComponent } from "./logout/logout.component";
import { RegisterComponent } from "./register/register.component";

const routes : Routes = [
    {
        path : 'auth/login',
        component : LoginComponent
    },
    {
        path : 'auth/register',
        component : RegisterComponent
    },
    {
        path : 'auth/logout',
        component : LogoutComponent
    }
];

export const AuthRoutingModule = RouterModule.forChild(routes);
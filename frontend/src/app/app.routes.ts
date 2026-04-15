import { Routes } from '@angular/router';
import { LoginPage } from './features/auth/pages/login-page';
import { RegisterPage } from './features/auth/pages/register-page';
import { HomePage } from './features/home/pages/home-page';

export const routes: Routes = [
	{ path: '', pathMatch: 'full', redirectTo: 'login' },
	{ path: 'login', component: LoginPage },
	{ path: 'register', component: RegisterPage },
	{ path: 'home', component: HomePage },
	{ path: '**', redirectTo: 'login' }
];

import { NgModule } from '@angular/core';
import { AuthGuard } from './auth.guard';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './Components/admin/admin.component';
import { UserComponent } from './Components/user/user.component';
import { LoginComponent } from './Components/login/login.component';
import { UnauthorizedComponent } from './Components/unauthorized/unauthorized.component';

import {LandingComponent} from './Components/landing/landing.component';
import { RegistrationFormComponent } from './Components/registration-form/registration-form.component';
const routes: Routes = [
  { path: '', redirectTo: '/landing', pathMatch: 'full' },
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard], data: { role: 'admin' } },
  { path: 'login', component: LoginComponent },
  { path: 'unauthorized', component: UnauthorizedComponent },
  { path: 'user', component: UserComponent, canActivate: [AuthGuard], data: { role: 'user' } },
  { path: 'landing', component: LandingComponent },
  { path: 'landing/:section', component: LandingComponent },
  { path: 'registration', component: RegistrationFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

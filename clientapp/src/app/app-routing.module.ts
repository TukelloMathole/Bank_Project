import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { AdminComponent } from './Components/admin/admin.component';
import { UserComponent } from './Components/user/user.component';
import { LoginComponent } from './Components/login/login.component';
import { UnauthorizedComponent } from './Components/unauthorized/unauthorized.component';
import { LandingComponent } from './Components/landing/landing.component';
import { RegistrationFormComponent } from './Components/registration-form/registration-form.component';
import { UserProfileComponent } from './Components/user/Components/user-profile/user-profile.component';
import { UserAccountsComponent } from './Components/user/Components/user-accounts/user-accounts.component';
import { UserTransactionsComponent } from './Components/user/Components/user-transactions/user-transactions.component';

const routes: Routes = [
  { path: '', redirectTo: '/landing', pathMatch: 'full' },
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard], data: { role: 'admin' } },
  { path: 'login', component: LoginComponent },
  { path: 'unauthorized', component: UnauthorizedComponent },
  { path: 'landing', component: LandingComponent },
  { path: 'landing/:section', component: LandingComponent },
  { path: 'registration', component: RegistrationFormComponent },
  {
    path: 'user',
    component: UserComponent,
    canActivate: [AuthGuard],
    data: { role: 'user' },
    children: [
      { path: '', redirectTo: 'accounts', pathMatch: 'full' },
      { path: 'settings', component: UserProfileComponent },
      { path: 'accounts', component: UserAccountsComponent },
      { path: 'transactions', component: UserTransactionsComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { AdminComponent } from './Components/admin/admin.component';
import { UserComponent } from './Components/user/user.component';
import { LoginComponent } from './Components/login/login.component';
import { UnauthorizedComponent } from './Components/unauthorized/unauthorized.component';
import { LandingComponent } from './Components/landing/landing.component';
import { RegistrationFormComponent } from './Components/registration-form/registration-form.component';
import { UserSettingsComponent } from './Components/user/Components/user-settings/user-settings.component';  // Adjusted import
import { UserAccountsComponent } from './Components/user/Components/user-accounts/user-accounts.component';  // Adjusted import
import { UserTransactionsComponent } from './Components/user/Components/user-transactions/user-transactions.component';  // Adjusted import

const userRoutes: Routes = [
  {
    path: 'user',
    component: UserComponent,
    canActivate: [AuthGuard],
    data: { role: 'user' },
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'settings', component: UserSettingsComponent },  // Adjusted component name
      { path: 'accounts', component: UserAccountsComponent },  // Adjusted component name
      { path: 'transactions', component: UserTransactionsComponent }  // Adjusted component name
    ]
  }
];

const routes: Routes = [
  { path: '', redirectTo: '/landing', pathMatch: 'full' },
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard], data: { role: 'admin' } },
  { path: 'login', component: LoginComponent },
  { path: 'unauthorized', component: UnauthorizedComponent },
  { path: 'landing', component: LandingComponent },
  { path: 'landing/:section', component: LandingComponent },
  { path: 'registration', component: RegistrationFormComponent },
  ...userRoutes  // Include child routes for 'user' under the root routes
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

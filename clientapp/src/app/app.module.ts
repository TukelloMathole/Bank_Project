import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { WebcamModule } from 'ngx-webcam';
import { AuthService } from './auth.service';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LandingComponent } from './Components/landing/landing.component';
import { NavigationComponent } from './Components/navigation/navigation.component';
import { RegistrationFormComponent } from './Components/registration-form/registration-form.component';
import { NotificationComponent } from './Components/notification/notification.component';
import { UserComponent } from './Components/user/user.component';
import { LoginComponent } from './Components/login/login.component';
import { UnauthorizedComponent } from './Components/unauthorized/unauthorized.component';
import { UserSettingsComponent } from './Components/user/Components/user-settings/user-settings.component';
import { UserAccountsComponent } from './Components/user/Components/user-accounts/user-accounts.component';
import { UserTransactionsComponent } from './Components/user/Components/user-transactions/user-transactions.component';
import { AccountService } from './Services/account.service';

@NgModule({
  declarations: [
    AppComponent,
    LandingComponent,
    NavigationComponent,
    RegistrationFormComponent,
    NotificationComponent,
    UserComponent,
    LoginComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    WebcamModule,
    RouterModule,
    UnauthorizedComponent,
    UserSettingsComponent,
    //UserAccountsComponent,
    UserTransactionsComponent,
    
  ],
  providers: [
    AuthService,
    AccountService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../../../Services/account.service'; // Adjust path as per your project structure
import { CommonModule } from '@angular/common';
import { PopupComponent } from '../popup/popup.component'; // Adjust the path accordingly

@Component({
  selector: 'app-user-accounts',
  templateUrl: './user-accounts.component.html',
  styleUrls: ['./user-accounts.component.css'],
  standalone: true,
  imports: [CommonModule, PopupComponent],
})
export class UserAccountsComponent implements OnInit {
  account: any;
  settings: any = {};
  alerts: any[] = [];

  isPopupOpen = false;
  selectedAccount: any;

  openPopup(account: any) {
    console.log("clicked");
    // this.selectedAccount = account;
    // this.isPopupOpen = true;
  }

  closePopup() {
    this.isPopupOpen = false;
    this.selectedAccount = null;
  }

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.fetchAccountDetails();
    this.fetchSettings();
    this.fetchAlerts();
  }

  fetchAccountDetails(): void {
    this.accountService.getAccountDetails().subscribe((data) => {
      this.account = data;
      console.log(this.account)
    });
  }

  fetchSettings(): void {
    this.accountService.getAccountSettings().subscribe((data) => {
      this.settings = data;
    });
  }

  fetchAlerts(): void {
    this.accountService.getAccountAlerts().subscribe((data) => {
      this.alerts = data;
    });
  }

  saveSettings(): void {
    this.accountService.updateAccountSettings(this.settings).subscribe(() => {
      alert('Settings saved successfully!');
    });
  }
}

import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../../../Services/account.service'; // Adjust path as per your project structure
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-accounts',
  templateUrl: './user-accounts.component.html',
  styleUrls: ['./user-accounts.component.css'],
  standalone: true,
  imports: [CommonModule],
})
export class UserAccountsComponent implements OnInit {
  account: any;
  settings: any = {};

  alerts: any[] = []; // Array to store notifications/alerts
  hasNewNotifications: boolean = false; // Flag to indicate if there are new notifications
  showNotifications: boolean = false;

  cards: any[] = [];
  constructor(private accountService: AccountService) { }


  
  ngOnInit(): void {
    this.fetchAccountDetails();
    this.fetchSettings();
    this.fetchAlerts();
  }

  fetchAccountDetails(): void {
    this.accountService.getAccountDetails().subscribe((data) => {
      this.cards = data.map((account: any) => ({
        type: account.accountType, // Assuming accountType maps to type in cards
        logoColor: '#ff9800', // Example logo color
        logoPath: this.getLogoPath(account.accountType), // Example function to get logo path
        number: this.maskAccountNumber(account.accountNumber), // Example function to mask account number
        validThru: this.getValidThru(account.expiryDate), // Example function to format expiry date
        cardholder: this.formatCardholder(account.firstName, account.middleName, account.lastName), // Example cardholder name
        balance: account.balance, // Example balance
        status: account.status, // Example status
        accountNumber: this.maskAccountNumber(account.accountNumber),
        CVV: account.cvv // Example masked account number
      }));
    });
  }

  // Example function to get logo path based on account type
  getLogoPath(accountType: string): string {
    // Implement logic to return logo path based on accountType
    return 'path_to_logo';
  }
  formatCardholder(firstName: string, middleName: string, lastName: string): string {
    let formattedLastName = lastName.toUpperCase().charAt(0) + lastName.slice(1); // Make first letter of last name uppercase

    // Get first letters of first name and middle name and capitalize them
    let initials = (firstName ? firstName.charAt(0).toUpperCase() : '') +
                   (middleName ? middleName.charAt(0).toUpperCase() : '');

    return initials + ' ' + formattedLastName;
  }
  // Example function to mask account number
  maskAccountNumber(accountNumber: string): string {
    // Implement logic to mask account number if needed
    return 'XXXX-XXXX-XXXX-' + accountNumber.slice(-4);
  }

  // Example function to format expiry date
  getValidThru(expiryDate: string): string {
    // Implement logic to format expiry date if needed
    return expiryDate.slice(5, 7) + ' / ' + expiryDate.slice(2, 4);
  }

  fetchSettings(): void {
    this.accountService.getAccountSettings().subscribe((data) => {
      this.settings = data;
    });
  }
  fetchAlerts(): void {
    this.accountService.getAccountAlerts().subscribe((data) => {
      this.alerts = data; // Populate alerts array with data fetched from service
      // Check if there are new notifications to show the red dot/star indicator
      this.hasNewNotifications = this.alerts.some(alert => !alert.read); // Example: Assuming alerts have a 'read' property
    });
  }
  toggleNotifications(): void {
    this.showNotifications = !this.showNotifications; // Toggle show/hide notifications
  }

  markAsRead(alert: any): void {
    alert.read = true; // Example: Marking an alert as read, update based on your data structure
    // Update backend or any additional logic as needed
  }

  saveSettings(): void {
    this.accountService.updateAccountSettings(this.settings).subscribe(() => {
      alert('Settings saved successfully!');
    });
  }
}

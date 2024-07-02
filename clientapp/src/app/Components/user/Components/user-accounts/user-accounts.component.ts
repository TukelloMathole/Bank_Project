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
  alerts: any[] = [];


  cards = [
    {
      type: 'MASTERCARD',
      logoColor: '#ff9800',
      logoPath: 'M32 10A14 14 0 1 0 32 38A14 14 0 1 0 32 10Z',
      number: '9759 2484 5269 6576',
      validThru: '1 2 / 2 4',
      cardholder: 'TC Mathole',
      balance: '$70,000',
      status: 'Active',
      accountNumber: 'XXXX-XXXX-XXXX-1234'
    },
    {
      type: 'MASTERCARD',
      logoColor: '#ff9800',
      logoPath: 'M32 10A14 14 0 1 0 32 38A14 14 0 1 0 32 10Z',
      number: '9759 2484 5269 6576',
      validThru: '1 2 / 2 4',
      cardholder: 'TC Mathole',
      balance: '$70,000',
      status: 'Active',
      accountNumber: 'XXXX-XXXX-XXXX-1234'
    },
    {
      type: 'VISA',
      logoColor: '#1a237e',
      logoPath: 'M16 10A6 6 0 1 0 16 22A6 6 0 1 0 16 10Z',
      number: '4897 6542 1234 5678',
      validThru: '5 8 / 2 5',
      cardholder: 'TC Mathole',
      balance: '$45,200',
      status: 'Active',
      accountNumber: 'XXXX-XXXX-XXXX-5678'
    },
    {
      type: 'DISCOVER',
      logoColor: '#ff3d00',
      logoPath: 'M16 10A6 6 0 1 0 16 22A6 6 0 1 0 16 10Z',
      number: '3540 1234 5678 9012',
      validThru: '3 1 / 2 3',
      cardholder: 'TC Mathole',
      balance: '$32,000',
      status: 'Active',
      accountNumber: 'XXXX-XXXX-XXXX-9012'
    },
    {
      type: 'Investment',
      logoColor: '#ff3d00',
      logoPath: 'M16 10A6 6 0 1 0 16 22A6 6 0 1 0 16 10Z',
      number: '3540 1234 5678 9012',
      validThru: '3 1 / 2 3',
      cardholder: 'TC Mathole',
      balance: '$32,000',
      status: 'Active',
      accountNumber: 'XXXX-XXXX-XXXX-9012'
    },
  ];
  constructor(private accountService: AccountService) { }


  
  ngOnInit(): void {
    this.fetchAccountDetails();
    this.fetchSettings();
    this.fetchAlerts();
  }

  fetchAccountDetails(): void {
    this.accountService.getAccountDetails().subscribe((data) => {
      this.account = data;
      console.log("this account details",this.account)
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

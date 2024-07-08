import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  user: any = {};  // Initialize as an empty object or define an interface/type
  selectedAccount: string = '';  // Initialize with an empty string or default value

  constructor() {}

  ngOnInit(): void {
    // Simulated data or fetch user data from a service
    this.user = {
      name: 'John Doe',
      email: 'johndoe@example.com',
      accounts: [
        { accountNumber: 'XXXXXXXX1234' },
        { accountNumber: 'XXXXXXXX5678' }
        // Add more accounts as needed
      ]
      // Add more properties as needed
    };
  }

  editProfile(): void {
    // Implement edit profile logic
    console.log('Editing profile...');
    // Example: navigate to edit profile route or open a modal
  }

  changePin(accountNumber: string): void {
    // Implement change PIN logic
    console.log(`Changing PIN for account: ${accountNumber}`);
    // Example: make API call to change PIN
  }
}

import { Component, OnInit } from '@angular/core';
import { TransactionService } from '../../../../Services/transaction.service'; // Adjust the path if necessary

@Component({
  selector: 'app-user-transactions',
  templateUrl: './user-transactions.component.html',
  styleUrls: ['./user-transactions.component.css']
})
export class UserTransactionsComponent implements OnInit {
  transactions: any[] = [];
  currentPage: number = 1;
  hasNextPage: boolean = false;
  hasPrevPage: boolean = false;
  showFundTransferForm: boolean = false;
  showRecurringTransactionForm: boolean = false;
  transferData: any = {
    fromAccount: '',
    toAccount: '',
    amount: null,
    type: 'own' // Default to own account transfer
  };
  recurringData: any = {
    fromAccount: '',
    toAccount: '',
    amount: null,
    frequency: 'monthly' // Default frequency for recurring transactions
  };

  constructor(private transactionService: TransactionService) {}

  ngOnInit(): void {
    this.fetchTransactions();
  }

  fetchTransactions(): void {
    this.transactionService.getTransactions().subscribe((data: any) => {
      this.transactions = data;
      console.log(this.transactions);
    });
  }

  downloadStatement(): void {
    // Implement the logic to download the statement
    console.log('Downloading statement...');
  }

  makeTransaction(): void {
    // Implement the logic to make a transaction
    console.log('Initiating transaction...');
  }

  toggleFundTransfer(): void {
    this.showFundTransferForm = !this.showFundTransferForm;
    this.showRecurringTransactionForm = false; // Close recurring form if open
  }

  toggleRecurringTransaction(): void {
    this.showRecurringTransactionForm = !this.showRecurringTransactionForm;
    this.showFundTransferForm = false; // Close fund transfer form if open
  }

  transferFunds(): void {
    // Implement logic to transfer funds
    console.log('Transferring funds...', this.transferData);
    // Example: Call transactionService.transferFunds(this.transferData)
  }

  setRecurringTransaction(): void {
    // Implement logic to set recurring transaction
    console.log('Setting recurring transaction...', this.recurringData);
    // Example: Call transactionService.setRecurringTransaction(this.recurringData)
  }

  prevPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.fetchTransactions();
    }
  }

  nextPage(): void {
    this.currentPage++;
    this.fetchTransactions();
  }
  cancelTransfer(): void {
    this.closeForm();
  }

  private closeForm(): void {
    this.showFundTransferForm = false;
    // Optionally reset form data here if needed
    this.resetForm();
  }
  private resetForm(): void {
    this.transferData = {
      fromAccount: '',
      toAccount: '',
      amount: null,
      type: 'own'
    };
  }
}

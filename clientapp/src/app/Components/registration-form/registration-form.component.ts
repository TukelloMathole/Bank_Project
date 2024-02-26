import { Component, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements AfterViewInit {
  currentStep: number = 1;
  formData: any = {};
  showPreview: boolean = false;
  accountTypes: string[] = ['Personal', 'Business', 'Youth', 'Seniors'];
  selectedAccountType!: string;
  pin1!: string;
  pin2!: string;
  constructor(private http: HttpClient) {}


  ngAfterViewInit(): void {
    // Implement any logic that needs to be executed after the view is initialized
  }

  nextStep(): void {
    if (this.currentStep < 4) {
      this.currentStep++;
    }
    // Check if both pins are entered and match
    if (this.pin1 && this.pin2 && this.pin1 === this.pin2) {
      // If the pins match, proceed to the next step
      // Add your logic for navigating to the next step here
    } else {
      // If the pins don't match, show an error or handle it accordingly
      console.error("Pins don't match");
      // You can add your error handling logic here
    }
  }

  previousStep(): void {
    if (this.currentStep > 1) {
      this.currentStep--;
    }
  }

  submitForm(): void {
    // URL where you want to post the form data
    const url = 'http://localhost:5028/BankAccountRegistration';

    // Make the HTTP POST request with the form data
    this.http.post(url, this.formData)
      .subscribe(
        (response) => {
          // Handle successful response here
          console.log('Form submitted successfully:', response);
          // Reset form data and step
          this.formData = {};
          this.currentStep = 1;
        },
        (error) => {
          // Handle error here
          console.error('Error submitting form:', error);
        }
      );
  }
}

import { Component, AfterViewInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

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

  idType: string = 'SA'; // Default to South African ID Number

toggleIDType() {
  // Implement your logic to toggle between South African ID and foreign passport
}
  ngAfterViewInit(): void {
    // Implement any logic that needs to be executed after the view is initialized
  }

  nextStep(): void {
    if (this.currentStep < 4) {
      this.currentStep++;
    }
    // Check if both pins are entered and match
    // if (this.pin1 && this.pin2 && this.pin1 === this.pin2) {
    //   // If the pins match, proceed to the next step
    //   // Add your logic for navigating to the next step here
    // } else {
    //   // If the pins don't match, show an error or handle it accordingly
    //   console.error("Pins don't match");
    //   // You can add your error handling logic here
    // }
  }

  previousStep(): void {
    if (this.currentStep > 1) {
      this.currentStep--;
    }
  }
  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      // Read the selected file as a data URL
      const reader = new FileReader();
      reader.onload = (e: any) => {
        // Set the data URL as the value of formData.idImage
        this.formData.idImage = e.target.result;
      };
      reader.readAsDataURL(file);
    }
  }
  submitForm(): void {
    // URL where you want to post the form data
    const url = 'https://localhost:7066/BankAccountRegistration';

    // Make the HTTP POST request with the form data
    this.http.post(url, this.formData, { responseType: 'text' }) // Specify responseType as text
  .subscribe(
    (response: any) => {
      // Handle successful response here
      console.log('Response:', response);
      // Since the response is in text format, you can directly check the response text
      if (response && response.includes('registered successfully')) {
        // Registration successful
        console.log('Registration successful');
        // Optionally, reset form data
        this.formData = {};
      } else {
        // Handle other cases where the response is unexpected
        console.error('Unexpected response:', response);
      }
    },
    (error: HttpErrorResponse) => {
      // Handle error here
      console.error('Error submitting form:', error);
      // Optionally, reset form data on error
      // this.formData = {};
    }
  );
  }
}

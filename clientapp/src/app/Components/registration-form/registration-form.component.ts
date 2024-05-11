import { Component, AfterViewInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { WebcamImage } from 'ngx-webcam';
import { Subject } from 'rxjs';

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
  triggerObservable = new Subject<void>();
  capturedImage: string | undefined;
  idType: string = 'SA'; // Default to South African ID Number

  constructor(private http: HttpClient) { }

  // Handle image capture
  handleImageCapture(webcamImage: WebcamImage) {
    this.capturedImage = webcamImage.imageAsDataUrl;
  }

  // Method to trigger image capture
  captureImage() {
    this.triggerObservable.next();
  }

  // Method to send images to backend API
  sendImagesToBackend() {
    console.log("verifying")
    // Prepare data to send to the API
    const imageData = {
      capturedImage: this.capturedImage,
      idImage: this.formData.idImage
    };

    // Send data to the backend API
    this.http.post<any>('your-api-url', imageData).subscribe(
      response => {
        console.log('API Response:', response);
        // Handle API response as needed
      },
      error => {
        console.error('API Error:', error);
        // Handle API error as needed
      }
    );
  }

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
    this.http.post(url, this.formData, { responseType: 'text' })
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

import { Component, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements AfterViewInit {
  currentStep: number = 1;
  formData: any = {};
  showPreview: boolean = false;

  constructor() {}

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

  submitForm(): void {
    // Process form data
    console.log(this.formData);
    // Reset form data and step
    this.formData = {};
    this.currentStep = 1;
  }
}

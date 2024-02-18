import { Component, ElementRef, ViewChild, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements AfterViewInit {
  currentStep: number = 1;
  formData: any = {};
  showPreview: boolean = false;
  selfieDataUrl: string | undefined;
  isCameraStarted: boolean = false;

  @ViewChild('video') videoElement!: ElementRef;
  @ViewChild('canvas') canvas!: ElementRef;
  videoWidth: number = 0;
  videoHeight: number = 0;

  constructor() {}

  ngAfterViewInit() {
    // Call startCamera() only after ViewChild references are initialized
    this.startCamera();
  }

  async startCamera() {
    try {
      const stream = await navigator.mediaDevices.getUserMedia({ video: true });
      this.videoElement.nativeElement.srcObject = stream;
      this.videoElement.nativeElement.play();
      this.videoWidth = this.videoElement.nativeElement.videoWidth;
      this.videoHeight = this.videoElement.nativeElement.videoHeight;
      this.isCameraStarted = true; // Update flag to indicate camera is started
    } catch (err: any) {
      // Handle permission denied or other errors
      console.error("Error accessing the camera: ", err);
      if (err.name === 'NotAllowedError') {
        // Handle permission denied error
        console.error("Permission to access camera was denied by the user.");
      } else {
        // Handle other errors
        console.error("Error accessing camera:", err);
      }
    }
  }
  

  takeSelfie(): void {
    const context = this.canvas.nativeElement.getContext('2d');
    context.drawImage(this.videoElement.nativeElement, 0, 0, this.videoWidth, this.videoHeight);
    this.selfieDataUrl = this.canvas.nativeElement.toDataURL('image/png');
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

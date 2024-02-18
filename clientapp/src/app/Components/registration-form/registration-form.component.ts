import { Component, ElementRef, AfterViewInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements AfterViewInit {
  currentStep: number = 1;
  formData: any = {};
  showPreview: boolean = false;
  capturedImage: any;
  @ViewChild('canvas') canvas?: ElementRef<HTMLCanvasElement>;
  @ViewChild('video') video?: ElementRef<HTMLVideoElement>;

  constructor() {}

  ngAfterViewInit(): void {
    this.initializeCamera();
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
    // Process form data here
    console.log(this.formData);
    // Reset form data and step
    this.formData = {};
    this.currentStep = 1;
  }

  initializeCamera() {
    if (this.video && this.canvas) {
      const videoElement = this.video.nativeElement;
      const canvasElement = this.canvas.nativeElement;
      navigator.mediaDevices.getUserMedia({ video: true })
        .then(stream => {
          videoElement.srcObject = stream;
        })
        .catch(err => console.error(err));
    }
  }

  takePicture() {
    if (this.video && this.canvas) {
      const videoElement = this.video.nativeElement;
      const canvasElement = this.canvas.nativeElement;
      const context = canvasElement.getContext('2d');
      if (context) {
        context.drawImage(videoElement, 0, 0, canvasElement.width, canvasElement.height);
        const imageData = canvasElement.toDataURL('image/png');
        // Now you have the image data, you can upload it or perform further actions.
        console.log(imageData);
        // Optionally, you can display the captured image
        this.capturedImage = imageData;
        this.showPreview = true;
      } else {
        console.error('Failed to get 2D context for canvas');
      }
    }
  }
}

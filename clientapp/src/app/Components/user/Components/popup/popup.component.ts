import { Component, Input, Output, EventEmitter } from '@angular/core';
@Component({
  selector: 'app-popup',
  standalone: true,
  imports: [],
  templateUrl: './popup.component.html',
  styleUrl: './popup.component.css'
})
export class PopupComponent {
  @Input() account: any;
  @Output() close = new EventEmitter<void>();

  closePopup(event?: MouseEvent) {
    if (event && (event.target as HTMLElement).classList.contains('fixed')) {
      this.close.emit();
    }
  }
}
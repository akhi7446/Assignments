import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [MatToolbarModule],
  template: `
    <mat-toolbar color="primary">
      Keep
    </mat-toolbar>
  `,
  styles: [`
    mat-toolbar {
      font-size: 20px;
      font-weight: bold;
    }
  `]
})
export class HeaderComponent {}

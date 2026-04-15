import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register-page',
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './register-page.html',
  styleUrl: './register-page.css'
})
export class RegisterPage {
  private readonly authService = inject(AuthService);

  email = '';
  password = '';
  message = '';
  isLoading = false;

  onRegister(): void {
    this.isLoading = true;
    this.message = '';

    this.authService.register({ email: this.email, password: this.password }).subscribe({
      next: (response) => {
        this.message = response.message || 'Register successful.';
        localStorage.setItem('token', response.token);
      },
      error: () => {
        this.message = 'Register failed. Try a different email.';
      },
      complete: () => {
        this.isLoading = false;
      }
    });
  }
}

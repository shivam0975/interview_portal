import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login-page',
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './login-page.html',
  styleUrl: './login-page.css'
})
export class LoginPage {
  private readonly authService = inject(AuthService);

  email = '';
  password = '';
  message = '';
  isLoading = false;

  onLogin(): void {
    this.isLoading = true;
    this.message = '';

    this.authService.login({ email: this.email, password: this.password }).subscribe({
      next: (response) => {
        this.message = response.message || 'Login successful.';
        localStorage.setItem('token', response.token);
      },
      error: () => {
        this.message = 'Login failed. Check your email and password.';
      },
      complete: () => {
        this.isLoading = false;
      }
    });
  }
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/core/services/auth.service';
import { take } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ToastService } from 'src/app/core/services/toast.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  error: string;
  constructor(private fb: FormBuilder, private authService: AuthService, private toastService: ToastService) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, Validators.required],
    });
  }

  login(): void {
    if (this.loginForm.valid) {
      this.error = null;
      this.authService.login(this.loginForm.value)
        .pipe(
          take(1)
        )
        .subscribe({
          next: () => this.toastService.success('Login Success'),
          error: (err: HttpErrorResponse) => {
            this.toastService.error('Incorrect credentials');
            this.error = err.message;
          }
        });
    }
  }
}

import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/app.auth.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'dmd-test-app';

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.authenticationService.login('admin', 'admin') // HARDCODED CREDS
    .pipe(first())
            .subscribe(
                data => {
                },
                error => {
                  alert('cannot get token');
                });
  }
}

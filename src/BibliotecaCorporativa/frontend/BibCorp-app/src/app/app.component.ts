import { Component } from '@angular/core'
import { Router } from '@angular/router';
import { NgbConfig } from '@ng-bootstrap/ng-bootstrap'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor (
    //    private loginLogoutService: LoginLogoutService
    private router: Router
  ) {}

  ngOnInit (): void {
  //  this.setCurrentUser();
  }

  showDrawer():boolean{
    return this.router.url != '/login' && this.router.url != '/cadastroUsuario';  
  }

/*  public setCurrentUser(): void {
    let user = {} as Users;

    if (localStorage.getItem(Constants.LOCAL_STORAGE_NAME))
      user = JSON.parse(localStorage.getItem(Constants.LOCAL_STORAGE_NAME) ?? '{}');

    if (user)
      this.loginLogoutService.setCurrentUser(user);
  } */
}

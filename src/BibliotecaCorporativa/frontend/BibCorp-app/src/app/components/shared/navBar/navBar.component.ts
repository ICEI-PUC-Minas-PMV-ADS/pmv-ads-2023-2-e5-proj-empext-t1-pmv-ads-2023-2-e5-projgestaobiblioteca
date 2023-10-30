import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router'
import { LoginService } from 'src/app/services';

@Component({
  selector: 'app-navBar',
  templateUrl: './navBar.component.html',
  styleUrls: ['./navBar.component.scss']
})
export class NavBarComponent implements OnInit {
  public isCollapsed = true

  constructor(
    private router: Router,
    private loginService: LoginService
    ) { }

  ngOnInit() {
  }

  public logout(): void{
    this.loginService.logout();
    this.router.navigateByUrl('usuarios/login');

  }
}

import { AppComponent } from './app.component'
import { BrowserModule } from '@angular/platform-browser'
import { AppRoutingModule } from './app-routing.module'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { NgbCollapseModule, NgbModule } from '@ng-bootstrap/ng-bootstrap'

import { MatSidenavModule } from '@angular/material/sidenav'
import { MatIconModule } from '@angular/material/icon'
import { MatInputModule } from '@angular/material/input'
import { MatFormFieldModule } from '@angular/material/form-field'
import { FormsModule } from '@angular/forms'

<<<<<<< Updated upstream
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core'
import { NavBarComponent } from './components'
import { PrincipalComponent } from './components/Principal/Principal.component'
=======
import { 
  NavBarComponent, 
  PrincipalComponent 
} from './components';
import { LoginComponent } from './components/login/login.component';
import { CadastroUsuarioComponent } from './components/cadastroUsuario/cadastroUsuario.component'
import { LoginService } from './services/Login/Login.service'
import { UsuarioService } from './services/Usuario/Usuario.service';
import { DetalhesComponent } from './components/detalhes/detalhes.component'
>>>>>>> Stashed changes

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
<<<<<<< Updated upstream
    PrincipalComponent
=======
    PrincipalComponent,
    LoginComponent,
    CadastroUsuarioComponent,
    DetalhesComponent
>>>>>>> Stashed changes
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    NgbModule,
    NgbCollapseModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatSidenavModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }

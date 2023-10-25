/* eslint-disable @typescript-eslint/consistent-type-imports */
import { Component, OnInit } from '@angular/core'
import { NgxSpinnerService } from 'ngx-spinner'
import { ToastrService } from 'ngx-toastr'
import { Subject, debounceTime } from 'rxjs'
import { Acervo } from 'src/app/models'
import { AcervoService } from 'src/app/services'
import { LoginService } from 'src/app/services/Usuarios/Login'
import { Paginacao, ResultadoPaginado } from 'src/app/util'

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.scss']
})
export class PrincipalComponent implements OnInit {
  public acervos: Acervo[] = []
  public acervosRecentes: Acervo[] = []
  public acervosLidos: Acervo[] = []
  public acervosRecentesCategoria: Acervo[] = []

  public paginacao: Paginacao[] = []

  public generos: String[] = []

  public opcaoPesquisa: string = 'Todos' 
  public opcaoGeneroRecentes: string = 'Todos'
  public argumento: string = ''

  public filtroAcervo(): void {
    console.log ('Filtro: ', this.argumento, ' ', this.opcaoGeneroRecentes, ' ', this.opcaoPesquisa )
    this.spinnerService.show()
    
    this.acervoService
    .getAcervosRecentes(1, 4, this.argumento, this.opcaoPesquisa, this.opcaoGeneroRecentes)
    .subscribe(
      (retorno: ResultadoPaginado<Acervo[]>) => {
        this.acervosRecentes = retorno.resultado

        for (var acervo of this.acervosRecentes)
          this.generos.push(acervo.genero)

        this.generos = this.generos.filter((genero, i) => this.generos.indexOf(genero) === i)

        this.acervosLidos = retorno.resultado
      },
      (error: any) => {
        console.log("aqui 2")
        this.toastrService.error("Erro ao carregar Acervos", 'Erro!');
        console.error(error)
      }
    )
    .add(() => this.spinnerService.hide())
  }

  constructor (
    private acervoService: AcervoService,
    private toastrService: ToastrService,
    private spinnerService: NgxSpinnerService,
    private loginService: LoginService,
    private router: Router
  ) { }

  public ngOnInit (): void {
    this.getAcervosRecentes()
  }

  public getAcervosRecentes (): void {
    this.spinnerService.show()

    this.acervoService
    .getAcervosRecentes(1, 4, this.argumento, this.opcaoPesquisa, this.opcaoGeneroRecentes)
    .subscribe(
      (retorno: ResultadoPaginado<Acervo[]>) => {
        this.acervosRecentes = retorno.resultado

        for (var acervo of this.acervosRecentes)
          this.generos.push(acervo.genero)

        this.generos = this.generos.filter((genero, i) => this.generos.indexOf(genero) === i)

        this.acervosLidos = retorno.resultado
      },
      (error: any) => {
        console.log("aqui 2")
        this.toastrService.error("Erro ao carregar Acervos", 'Erro!');
        console.error(error)
      }
    )
    .add(() => this.spinnerService.hide())
  }

   public logout(): void{
    this.loginService.logout();
    this.router.navigateByUrl('/login');

  }
}

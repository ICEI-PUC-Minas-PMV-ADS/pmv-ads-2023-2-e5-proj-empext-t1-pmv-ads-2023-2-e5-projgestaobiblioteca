/* eslint-disable @typescript-eslint/consistent-type-imports */
import { Component, type OnInit } from '@angular/core'
import { Router } from '@angular/router'
import { NgxSpinnerService } from 'ngx-spinner'
import { ToastrService } from 'ngx-toastr'
import { Subject, debounceTime } from 'rxjs'
import { Acervo } from 'src/app/models'
import { AcervoService } from 'src/app/services'
import { LoginService } from 'src/app/services/Usuarios/Login'

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.scss']
})
export class PrincipalComponent implements OnInit {
  public acervos: Acervo[] = []
  public acervosRecentes: Acervo[] = []
  public acervosLidos: Acervo[] = []

  public  opcaoPesquisa: number = 1

  public pesquisarTudo = false
  public pesquisarPorAutor: boolean = false
  public pesquisarPorTitulo: boolean = false
  public pesquisarPorResumo: boolean = false

  private _filtroLista = ''

  public get filtroLista() {
    return this._filtroLista
  }

  public set filtroLista(value: string) {
    this._filtroLista = value
    this.acervosRecentes = this.filtroLista ? this.filtrarAcervos(this.filtroLista) : this.acervos
    this.acervosLidos = this.filtroLista ? this.filtrarAcervos(this.filtroLista) : this.acervos
  }
  
  public filtrarAcervos(filtrarPor: string): any {
    this.pesquisarTudo = false
    this.pesquisarPorAutor = false
    this.pesquisarPorTitulo = false
    this.pesquisarPorResumo = false

    if (this.opcaoPesquisa == 2)
      this.pesquisarPorAutor = true
    else if (this.opcaoPesquisa == 3)
      this.pesquisarPorResumo = true
    else if (this.opcaoPesquisa == 4)
      this.pesquisarPorTitulo = true
    else
      this.pesquisarTudo = true

    filtrarPor = filtrarPor.toLocaleLowerCase()
    console.log("opcaoPesquisa", this.opcaoPesquisa)
    return this.acervos.filter(
      (acervo: {titulo: string, subTitulo: string, autor: string, resumo: string}) => 
        ((this.pesquisarTudo || this.pesquisarPorTitulo) && acervo.titulo.toLocaleLowerCase().indexOf(filtrarPor) !== -1) ||
        ((this.pesquisarTudo || this.pesquisarPorTitulo) && acervo.subTitulo.toLocaleLowerCase().indexOf(filtrarPor) !== -1) ||
//         ((this.pesquisarTudo || this.pesquisarPorAuotr) && acervo.autor.toLocaleLowerCase().indexOf(filtrarPor) !== -1)  ||
        ((this.pesquisarTudo || this.pesquisarPorResumo) && acervo.resumo.toLocaleLowerCase().indexOf(filtrarPor) !== -1)
    )
  }

  public argumentoAlterado: Subject<string> = new Subject<string>();

  public filtroAcervo(event: any): void {
    if (this.argumentoAlterado.observers.length === 0) {
      console.log("aqui")
      this.spinnerService.show()
      this.argumentoAlterado
        .pipe(debounceTime(1500))
        .subscribe(
          filtrarPor => {
            this.acervoService
              .getAcervos(filtrarPor)
              .subscribe(
                (acervos: Acervo[]) => {
                  this.acervos = acervos;
                },
                (error: any) => {
                  console.log("aqui")
                  this.toastrService.error("Erro ao filtrar Acervos", 'Erro!');
                  console.error(error);
                }
              )
            .add(() => this.spinnerService.hide());
          }
        )
    }

    this.argumentoAlterado.next(event.value)
  }

  constructor (
    private acervoService: AcervoService,
    private toastrService: ToastrService,
    private spinnerService: NgxSpinnerService,
    private loginService: LoginService,
    private router: Router
  ) { }

  public ngOnInit (): void {
    this.spinnerService.show()
    console.log("opcaoPesquisa", this.opcaoPesquisa)

    this.getAcervos()
  }

  public getAcervos (): void {
    this.acervoService
    .getAcervos()
    .subscribe(
      (acervos: Acervo[]) => {
        this.acervos = acervos
        this.acervosRecentes = acervos
        this.acervosLidos = acervos
        console.log(this.acervos)
      },
      (error: any) => {
        console.log("aqui 2")
        this.toastrService.error("Erro ao carrgar Acervos", 'Erro!');
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

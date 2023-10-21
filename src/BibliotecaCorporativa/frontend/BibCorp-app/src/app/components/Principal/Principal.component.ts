/* eslint-disable @typescript-eslint/consistent-type-imports */
import { Component, type OnInit } from '@angular/core'
import { NgxSpinnerService } from 'ngx-spinner'
import { ToastrService } from 'ngx-toastr'
import { Subject, debounceTime } from 'rxjs'
import { Acervo } from 'src/app/models'
import { AcervoService } from 'src/app/services'

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.scss']
})
export class PrincipalComponent implements OnInit {
  public acervos: Acervo[] = []
  public acervosRecentes: Acervo[] = []
  public acervosLidos: Acervo[] = []

  public argumentoAlterado: Subject<string> = new Subject<string>();

  public filtroAcervo(event: any): void {
    if (this.argumentoAlterado.observers.length === 0) {
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
    private spinnerService: NgxSpinnerService
  ) { }

  public ngOnInit (): void {
    this.spinnerService.show()

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
}

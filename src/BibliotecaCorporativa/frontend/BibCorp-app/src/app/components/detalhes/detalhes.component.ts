import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Acervo } from 'src/app/models';
import { AcervoService } from 'src/app/services';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
  styleUrls: ['./detalhes.component.scss']
})
export class DetalhesComponent implements OnInit {
  public acervo: Acervo 
  public comentarios: string

  constructor(private acervoService: AcervoService,
    private toastrService: ToastrService,
    private spinnerService: NgxSpinnerService) { }

  public ngOnInit(): void {
    this.getAcervoById()
  }

  public getAcervoById(): void {
    this.spinnerService.show()

    this.acervoService
      .getAcervoById(1)
      .subscribe(
        (retorno: Acervo) => {
          this.acervo = retorno
          console.log(this.acervo)
        },
        (error: any) => {
          this.toastrService.error("Erro ao carregar Acervo", 'Erro!');
          console.error(error)
        }
      )
      .add(() => this.spinnerService.hide())
  }

   public salvarAcervo(): void{
      this.spinnerService.show()

      this.acervo.comentarios = this.comentarios
      this.acervoService
        .updateAcervo(1, this.acervo)

        .subscribe(
          (retorno: Acervo) => {
            this.acervo = retorno
            console.log(this.acervo)
            this.toastrService.success("Comentário incluído para o acervo!", 'Salvo!');
          },
          (error: any) => {
            this.toastrService.error("Erro ao salvar acervo", 'Erro!');
            console.error(error)
          }
        )
        .add(() => this.spinnerService.hide())
    }
   }


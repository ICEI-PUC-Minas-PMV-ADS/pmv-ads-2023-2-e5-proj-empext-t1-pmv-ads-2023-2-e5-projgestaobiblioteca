import { Component, Inject, OnInit } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialog } from "@angular/material/dialog";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { formatDate } from "@angular/common";
import { Emprestimo, EmprestimoService } from "src/app/emprestimos";
import { Usuario, UsuarioService } from "src/app/usuarios";
import { Acervo, AcervoService, ModalSucessoComponent } from "src/app/acervos";
import { Patrimonio, PatrimonioService } from "src/app/patrimonios";

@Component({
  selector: "app-pop-up",
  templateUrl: "./modalEmprestar.component.html",
  styleUrls: ["./modalEmprestar.component.scss"],
})
export class ModalEmprestarComponent implements OnInit {
  title = "angular-material";

  public acervo: Acervo;
  public acervoParam: any = "";
  public patrimonio: Patrimonio;
  public patrimonioParam: any = "";
  public emprestimo = {} as Emprestimo;
  public localEntrega: string;
  public localColeta: string;
  public usuarioAtivo = {} as Usuario;

  constructor(
    private dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA)
    public dataInput: { patrimonioId: number; acervoId: number; id: string },
    private acervoService: AcervoService,
    public usuarioService: UsuarioService,
    private patrimonioService: PatrimonioService,
    private emprestimoService: EmprestimoService,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.getUsuarioAtivo();
    this.acervoParam = this.dataInput.acervoId;
    this.getAcervoById();

    this.patrimonioParam = this.dataInput.patrimonioId;
    this.getPatrimonioById();
  }

  fecharModalEmprestarEAbrirModalSucesso() {
    const dialogRefEmprestar = this.dataInput.id;
    if (dialogRefEmprestar) {
      this.dialog.closeAll();
    }

    this.dialog.open(ModalSucessoComponent, {
      data: { localEntrega: this.emprestimo.localDeEntrega },
      id: "Sucesso",
    });
  }

  public getAcervoById(): void {
    this.spinnerService.show();

    this.acervoService
      .getAcervoById(+this.acervoParam)
      .subscribe(
        (retorno: Acervo) => {
          this.acervo = retorno;
          console.log(this.acervo);
        },
        (error: any) => {
          this.toastrService.error("Erro ao carregar Acervo", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getPatrimonioById(): void {
    this.spinnerService.show();

    this.patrimonioService
      .getPatrimonioById(+this.patrimonioParam)
      .subscribe(
        (retorno: Patrimonio) => {
          this.patrimonio = retorno;
          console.log(this.patrimonio);
        },
        (error: any) => {
          this.toastrService.error("Erro ao carregar Patrimonio", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public formatarData(data: Date): any{
    var dataFormatada = formatDate(data, "yyyy-MM-dd'T'HH:mm:ss","en-US")

    return dataFormatada
  }

  public novoEmprestimo(): void {
    this.spinnerService.show();

    let dataEmprestimo =  new Date();
    this.emprestimo.dataEmprestimo = this.formatarData(dataEmprestimo);

    let dataPrevista = new Date();
    dataPrevista.setDate(dataPrevista.getDate() + 30)
    this.emprestimo.dataPrevistaDevolucao = this.formatarData(dataPrevista)

    this.emprestimo.dataDevolucao = null;

    this.emprestimo.qtdeDiasAtraso = 0;
    this.emprestimo.qtdeDiasEmprestimo = 30;

    this.emprestimo.status = 1;

    this.emprestimo.acervoId = this.acervoParam;
    this.emprestimo.patrimonioId = this.patrimonioParam;

    this.emprestimo.localDeColeta = this.localColeta;
    this.emprestimo.localDeEntrega = this.localEntrega;

    this.emprestimo.userName = this.usuarioAtivo.userName;

    console.log(this.emprestimo);

    this.emprestimoService
      .createEmprestimo(this.emprestimo)
      .subscribe(
        () => {
          this.fecharModalEmprestarEAbrirModalSucesso();
        },
        (error: any) => {
          if (
            error.status === 400 &&
            error.error ==
              "Acervo não possui unidades disponíveis para empréstimo"
          ) {
            this.toastrService.error(
              "O livro escolhido não possui exemplares disponíveis para empréstimo no momento"
            );
          } else if (error.status === 500) {
            this.toastrService.error(
              "Ocorreu um erro ao tentar cadastrar o empréstimo"
            );
          }
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getUsuarioAtivo(): void {
    this.spinnerService.show();
    this.usuarioService
      .getUsuarioByUserName()
      .subscribe(
        (usuario: Usuario) => {
          this.usuarioAtivo = usuario;
        },
        (error: any) => {
          this.toastrService.error(
            "Ocorreu um erro ao tentar recuperar o usuário"
          );
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }
}

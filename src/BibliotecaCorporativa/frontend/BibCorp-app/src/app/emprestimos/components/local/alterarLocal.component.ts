import { Component, Inject, OnInit } from "@angular/core";
import { MatDialog, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Router } from "@angular/router";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { Emprestimo, EmprestimoService } from "src/app/emprestimos";
import { UsuarioService } from "src/app/usuarios";
import { ModalSucessoAlteracaoComponent } from "../modal/alteracao";

@Component({
  selector: "app-alterar-local",
  templateUrl: "./alterarLocal.component.html",
  styleUrls: ["./alterarLocal.component.scss"],
})
export class AlterarLocalComponent implements OnInit {
  title = "angular-material";

  public emprestimoIdParam: any = "";
  public novoLocalColeta: string;
  public localColetaAtual: string;
  public emprestimo = {} as Emprestimo;

  constructor(
    private dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA)
    public dataInput: { emprestimoId: number; localDeColetaAtual: string },
    private router: Router,
    private emprestimoService: EmprestimoService,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
    public usuarioService: UsuarioService
  ) {}

  ngOnInit(): void {
    this.emprestimoIdParam = this.dataInput.emprestimoId;
    this.localColetaAtual = this.dataInput.localDeColetaAtual;
  }

  fecharModalAlterarEAbrirModalSucesso() {
    const dialogRefAlterar = this.dataInput.emprestimoId;
    if (dialogRefAlterar) {
      this.dialog.closeAll();
    }

    this.dialog.open(ModalSucessoAlteracaoComponent, {
      data: { emprestimoId: this.emprestimoIdParam },
      id: "Sucesso",
    });
  }

  public alterarLocalDeColeta(): void {
    this.spinnerService.show();

    this.emprestimoService
      .alterarLocalDeColeta(this.emprestimoIdParam, this.novoLocalColeta)
      .subscribe(
        () => {
          this.fecharModalAlterarEAbrirModalSucesso();
        },
        (error: any) => {
          if (
            error.status === 400 &&
            error.error ==
              "Não é possível alterar o local de coleta de um empréstimo já devolvido"
          ) {
            this.toastrService.error(
              "Não será possível realizar a alteração solicitada pois o empréstimo já foi devolvido"
            );
          } else if (error.status === 500) {
            this.toastrService.error(
              "Ocorreu um erro ao tentar alterar o local de coleta"
            );
          }
        }
      )
      .add(() => this.spinnerService.hide());
  }
}

import { Component, OnInit, TemplateRef } from "@angular/core";

import { ToastrService } from "ngx-toastr";
import { NgxSpinnerService } from "ngx-spinner";

import { MatDialog } from "@angular/material/dialog";

import { NavigationEnd, Router } from "@angular/router";
import { formatDate } from "@angular/common";

import { Acervo, AcervoService } from "src/app/acervos";
import { AlterarLocalComponent, Emprestimo, EmprestimoService, ModalRenovarComponent } from "src/app/emprestimos";
import { LoginService, UsuarioLogin } from "src/app/usuarios";

@Component({
  selector: "app-minhasReservas",
  templateUrl: "./minhasReservas.component.html",
  styleUrls: ["./minhasReservas.component.scss"],
})
export class MinhasReservasComponent implements OnInit {
  title = "angular-material";

  // modalRef: BsModalRef;
  public emprestimos: Emprestimo[] = [];
  public emprestimosFiltrados: Emprestimo[] = [];

  public acervos: Acervo[] = [];
  public acervosFiltrados: Acervo[] = [];
  public acervo: Acervo;

  public usuarioLogado = false;
  public usuarioAtivo = {} as UsuarioLogin;

  public larguraImagem = 75;
  public margemImagem = 2;
  public exibirImagem = true;
  private filtroListado = "";

  //----------------------------------------------FILTROS--------------------------------------------------
  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.acervosFiltrados = this.filtroLista
      ? this.filtrarReservas(this.filtroLista)
      : this.acervos;
  }

  public filtrarReservas(filtrarPor: string): Acervo[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.acervos.filter(
      (livro) =>
        livro.titulo.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        livro.autor.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  //----------------------------------------------VERIFICAÇÃO DE USUARIO e MÉTODOS--------------------------------------------------

  constructor(
    private emprestimoService: EmprestimoService,
    private acervoService: AcervoService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private dialogRef: MatDialog,
    public loginService: LoginService,
    private router: Router
  ) {
    router.events.subscribe((verifyUser) => {
      if (verifyUser instanceof NavigationEnd)
        this.loginService.currentUser$.subscribe((userActive) => {
          this.usuarioLogado = userActive !== null;
          this.usuarioAtivo = { ...userActive };
        });
    });
  }

  public abrirDialogRenovacao(
    emprestimoId: number,
    acervoTitulo: string,
    dataPrevistaDevolucao: Date
  ) {
    this.dialogRef.open(ModalRenovarComponent, {
      data: {
        emprestimoId: emprestimoId,
        acervoTitulo: acervoTitulo,
        dataPrevistaDevolucao: dataPrevistaDevolucao,
        id: "Renovar",
      },
    });
  }

  public abrirDialogAlteracao(emprestimoId: number, localDeColetaAtual: string) {
    this.dialogRef.open(AlterarLocalComponent, {
      data: {
        emprestimoId: emprestimoId,
        localDeColetaAtual: localDeColetaAtual,
        id: "Alterar",
      },
    });
  }

  public ngOnInit(): void {
    this.spinner.show();
    // this.getPatrimonios();
    this.getEmprestimos(this.usuarioAtivo.userName);
    this.getAcervo();

    this.usuarioLogado = this.usuarioAtivo !== null;
  }

  public getEmprestimos(userName: string): void {
    this.emprestimoService.getEmprestimosByUserName(userName).subscribe({
      next: (Response: Emprestimo[]) => {
        this.emprestimos = Response;
        this.emprestimosFiltrados = this.emprestimos;
        console.log(this.emprestimosFiltrados);
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error("Erro ao buscar os empréstimos do usuario.", "Erro!");
      },
      complete: () => this.spinner.hide(),
    });
  }

  public getAcervo(): void {
    this.acervoService.getAcervos().subscribe({
      next: (Response: Acervo[]) => {
        this.acervos = Response;
        this.acervosFiltrados = this.acervos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error("Erro ao Carregar", "Erro!");
      },
      complete: () => this.spinner.hide(),
    });
  }

  public obterStatus(emprestimo: Emprestimo): any {
    let dataAtual = new Date()
    let dataPrevistaDevolucao = emprestimo.dataPrevistaDevolucao;

    if (dataPrevistaDevolucao < dataAtual &&
      emprestimo.dataDevolucao == null && (emprestimo.status == 2 || emprestimo.status == 4)
    ) { return "Em atraso";}
      else if (emprestimo.status == 1) {
      return "Aguardando aprovação da solicitação";
    } else if (emprestimo.status == 2) {
      return "Em andamento";
    } else if (emprestimo.status == 3) {
      return "Devolvido";
    } else if (emprestimo.status == 4) {
      return "Renovado";
    } else if (emprestimo.status == 5) {
      return "Não aprovado";
    } else return "-";
  }

  public formatarData(data: Date): any{
    if (data != null){
      var dataFormatada = formatDate(data, "dd/MM/YYYY","en-US")
    } else{
      dataFormatada = null
    }
    return dataFormatada
  }
}

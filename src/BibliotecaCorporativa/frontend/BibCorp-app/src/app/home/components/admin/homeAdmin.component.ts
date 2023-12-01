import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { Router } from "@angular/router";
import { formatDate } from "@angular/common";

import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { Acervo, AcervoService } from "src/app/acervos";

import { DeleteModalComponent, Paginacao, ResultadoPaginado } from "src/app/shared";
import { Emprestimo, EmprestimoService } from "src/app/emprestimos";
import { FiltroEmprestimo } from "src/app/emprestimos/models/emprestimo/FiltroEmprestimo";
import { Usuario, UsuarioService } from "src/app/usuarios";
import { __values } from "tslib";


@Component({
  selector: "app-home-admin",
  templateUrl: "./homeAdmin.component.html",
  styleUrls: ["./homeAdmin.component.scss"],
})
export class HomeAdminComponent implements OnInit {
  public emprestimos: Emprestimo[] = [];
  public filtroEmprestimo: FiltroEmprestimo;
  public usuarios: Usuario[] = [];

  public paginacao = {} as Paginacao;

  public exibirImagem: boolean = true;

  dataInicio: Date;
  dataFim: Date;
  selectedUser: string;
  showUserDropdown: boolean = false;
  usuario: string[] = [];

  constructor(
    private router: Router,
    public dialog: MatDialog,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
    private emprestimoService: EmprestimoService,
    private usuarioService: UsuarioService
  ) {}

  ngOnInit(): void {
    this.getAllEmprestimos()
    this.getAllusuarios()
    this.filtroEmprestimo = new FiltroEmprestimo
  }

  alterarImagem() {
    this.exibirImagem = !this.exibirImagem;
  }


  toggleUserDropdown() {
    this.showUserDropdown = !this.showUserDropdown;
  }

  onUserOptionChange() {
    // Lógica adicional, se necessário
  }

  selectedUsers: { [key: string]: boolean} = {};

  public getAllEmprestimos(): void {
    this.spinnerService.show();

    this.emprestimoService
      .getAllEmprestimos()
      .subscribe(
        (retorno: Emprestimo[]) => {
          this.emprestimos = retorno;
        },
        (error: any) => {
          this.toastrService.error("Erro ao buscar os empréstimos", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getEmprestimosFiltrados(dataInicio: Date, dataFim: Date, selectedUsers: { [key: string]: boolean} = {}): void {
    this.spinnerService.show();

    let usuarioParametro: any = ""
    let listaDeUsuarios: any = ""

    Object.keys(selectedUsers).forEach(user =>{
        usuarioParametro = `&Usuarios=${user}`
        listaDeUsuarios += usuarioParametro
    })

    this.filtroEmprestimo.dataInicio = dataInicio
    this.filtroEmprestimo.dataFim = dataFim
    this.filtroEmprestimo.usuarios = listaDeUsuarios

    this.emprestimoService
      .getEmprestimosFiltrados(this.filtroEmprestimo)
      .subscribe(
        (retorno: Emprestimo[]) => {
          this.emprestimos = retorno;
        },
        (error: any) => {
          this.toastrService.error("Erro ao buscar os empréstimos filtrados", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getAllusuarios(): void {
    this.spinnerService.show();

    this.usuarioService
      .getAllUsuarios()
      .subscribe(
        (retorno: Usuario[]) => {
          this.usuarios = retorno;
        },
        (error: any) => {
          this.toastrService.error("Erro ao buscar os usuários", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public formatarData(data: Date): any{

    if (data != null){
      var dataFormatada = formatDate(data, "dd/MM/YYYY","en-US")
    } else{
      dataFormatada = null
    }
    return dataFormatada
  }

  public obterStatus(emprestimo: Emprestimo): any {
    
    let dataAtual = this.formatarData(new Date());

    if (this.formatarData(emprestimo.dataPrevistaDevolucao) < dataAtual &&
      emprestimo.dataDevolucao == null && (emprestimo.status == 2 || emprestimo.status == 4)
    ) { 
      return "Em atraso";
    } 
      else if (emprestimo.status == 1) {
      return "Aguardando aprovação";
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


}

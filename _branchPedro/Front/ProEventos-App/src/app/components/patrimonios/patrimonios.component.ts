import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Patrimonio } from 'src/app/models/Patrimonio';
import { PatrimonioService } from 'src/app/services/patrimonio.service';

@Component({
  selector: 'app-patrimonios',
  templateUrl: './patrimonios.component.html',
  styleUrls: ['./patrimonios.component.scss']
})
export class PatrimoniosComponent implements OnInit {

  modalRef: BsModalRef;
  public patrimonios: Patrimonio[] = [];
  public patrimoniosFiltrados: Patrimonio[] = [];

  public larguraImagem = 75;
  public margemImagem = 2;
  public exibirImagem = true;
  private filtroListado = '';

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.patrimoniosFiltrados = this.filtroLista ? this.filtrarPatrimonios(this.filtroLista) : this.patrimonios;
  }

  public filtrarPatrimonios(filtrarPor: string): Patrimonio[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.patrimonios.filter(
      livro => livro.titulo.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      livro.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private patrimonioService: PatrimonioService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getPatrimonios();
  }

  public alterarImagem(): void {
    this.exibirImagem = !this.exibirImagem;
  }

  public getPatrimonios(): void {
    this.patrimonioService.getPatrimonio().subscribe({
      next: (patrimoniosResponse: Patrimonio[]) => {
        this.patrimonios = patrimoniosResponse;
        this.patrimoniosFiltrados = this.patrimonios;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar os Patrimonios', 'Erro!');
      },
      complete: () => this.spinner.hide()
    });
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef.hide();
    this.toastr.success('O Patrimonio foi deletado com Sucesso.', 'Deletado!');
  }

  decline(): void {
    this.modalRef.hide();
  }
}

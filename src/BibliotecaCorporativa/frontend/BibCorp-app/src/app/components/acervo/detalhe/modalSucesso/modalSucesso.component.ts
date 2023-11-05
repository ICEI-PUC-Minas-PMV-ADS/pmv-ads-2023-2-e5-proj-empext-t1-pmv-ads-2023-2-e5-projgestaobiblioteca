import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-modal-sucesso',
  templateUrl: './modalSucesso.component.html',
  styleUrls: ['./modalSucesso.component.scss']
})
export class ModalSucessoComponent {

  constructor(@Inject(MAT_DIALOG_DATA)
  public data: any,
  private router: Router,
  private dialog: MatDialog) {  }
  
  voltarParaAcervoDetalhe() {
    this.router.navigate(['/acervos/detalhe']); //direcionar para tela Meus Empréstimos/Minhas Reservas
  
    const dialogRefSucesso = this.dialog.getDialogById('Sucesso'); 
    if (dialogRefSucesso) {
      dialogRefSucesso.close();
    }
  }
  

}

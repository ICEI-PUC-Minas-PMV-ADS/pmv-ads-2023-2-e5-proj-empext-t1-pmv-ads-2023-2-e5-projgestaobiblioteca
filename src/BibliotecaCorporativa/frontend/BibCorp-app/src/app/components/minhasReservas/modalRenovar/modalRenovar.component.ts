import { Component, Inject, OnInit} from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-modal-renovar',
  templateUrl: './modalRenovar.component.html',
  styleUrls: ['./modalRenovar.component.scss']
})
export class ModalRenovarComponent implements OnInit {
  title = 'angular-material';

  constructor(@Inject(MAT_DIALOG_DATA) 
  private router: Router,
  private dialog: MatDialog) {  }

  ngOnInit(): void {
    
  }
  
  voltar() {
    this.router.navigate(['/acervos/detalhe']); 
}

}
import { Component, Input } from '@angular/core'

@Component({
  selector: 'app-livro',
  templateUrl: './livro.component.html',
  styleUrls: ['./livro.component.css']
})
export class LivroComponent {
  @Input() public titulo!: string
  @Input() public autor!: string
  @Input() public ano!: number
}

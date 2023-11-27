import { type Emprestimo } from '../../../emprestimos/models/emprestimo/Emprestimo'

export class Usuario{
    nome: string
    localizacao: string
    email: string
    password: string
    userName:string
    phoneNumber:string
    Emprestimos: Emprestimo[]
    token: string
}

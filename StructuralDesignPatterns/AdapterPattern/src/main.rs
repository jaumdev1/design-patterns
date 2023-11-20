trait NovoSistema {
    fn entrar(&self);
}
struct SistemaAntigo {
    nome: String,
}
impl SistemaAntigo {
    fn new(nome: String) -> SistemaAntigo {
        SistemaAntigo { nome }
    }

    fn login(&self) {
        println!("Bem-vindo à biblioteca, {}.", self.nome);
    }
}


struct Adapter {
    sistema_antigo: SistemaAntigo,
}

impl NovoSistema for Adapter {
    fn entrar(&self) {
        self.sistema_antigo.login();
    }
}

fn main() {

    let sistema_antigo = SistemaAntigo::new(String::from("João"));
    sistema_antigo.login();


    let adapter = Adapter { sistema_antigo };
    adapter.entrar();
}
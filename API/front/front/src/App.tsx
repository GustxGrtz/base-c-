import React from 'react';
import ListarAgendas from './components/listar-agenda';
import { BrowserRouter, Link, Route, Routes } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <header className="App-header">
          <h1>Agenda</h1>
            <div>
      <div>
        <BrowserRouter>
          <nav>
            <ul>
              <li>
                <Link to={"/"}>Home</Link>
              </li>
              <li>
                <Link to={"/pages/agendas/listar"}>
                  Listar Agendas{" "}
                </Link>
              </li>
              <li>
                <Link to={"/pages/agendas/listarconcluidas"}>
                  Listar Tarefas Concluídas{" "}
                </Link>
              </li>
              <li>
                <Link to={"/pages/agendas/listarnaoconcluidas"}>
                  Listar Tarefas Não Concluídas{" "}
                </Link>
              </li>
              <li>
                <Link to={"/pages/agendas/cadastrar"}>
                  Cadastrar Tarefa{" "}
                </Link>
              </li>
            </ul>
          </nav>
          <Routes>
            <Route path="/" element={<ListarAgendas />} />
            <Route
              path="/pages/agendas/listar"
              element={<ListarAgendas />}
            />
            {/* <Route
              path="/pages/tarefa/listarconcluidas"
              element={<ListarTarefasConcluidas />}
            />
            <Route
              path="/pages/tarefa/listarnaoconcluidas"
              element={<ListarTarefasNaoConcluidas />}
            />
            <Route
              path="/pages/tarefa/cadastrar"
              element={<CadastrarTarefa />}
            /> */}
          </Routes>
          <footer>
          </footer>
        </BrowserRouter>
      </div>
    </div>
      </header>
    </div>
  );
}

export default App;

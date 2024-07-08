import React, { useEffect, useState } from "react";
import { Agenda } from "../models/agenda";

function ListarAgendas() {

    const [agendas, setAgendas] = useState<Agenda[]>([]);

    useEffect(() => {
      carregarAgendas();
    }, []);
  
    function carregarAgendas() {
      //FETCH ou AXIOS
      fetch("http://localhost:5039/agendas/listar")
        .then((resposta) => resposta.json())
        .then((agendas: Agenda[]) => {
          console.table(agendas);
          setAgendas(agendas);
        });
    }

    return(
            <div>
              <h1>Listar Tarefas</h1>
              <table border={1}>
                <thead>
                  <tr>
                    <th>#</th>
                    <th>Títulos</th>
                    <th>Descrição</th>
                    <th>Status</th>
                    <th>Criado Em</th>
                    <th>Alterar Status</th>
                  </tr>
                </thead>
                <tbody>
                  {agendas.map((agenda) => (
                    <tr key={agenda.agendaId}>
                      <td>{agenda.agendaId}</td>
                      <td>{agenda.titulo}</td>
                      <td>{agenda.descricao}</td>
                      <td>{agenda.contato}</td>
                      <td>{agenda.status}</td>
                      <td>
                        <button
                        //   onClick={() => {
                        //     alterar(agenda.tarefaId!);
                        //   }}
                        >
                          Alterar
                        </button>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          );
        }

export default ListarAgendas;
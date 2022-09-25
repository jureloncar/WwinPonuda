import React, { useEffect, useState } from 'react';

function Turnir(){
  const [turniri, setTurniri] = useState([]);

  useEffect(()=>{
    fetch("https://localhost:7030/api/turnirs").then(res=>res.json()).then(
      result=>{
        setTurniri(result)
      }
    )
  }, [])

    return(
      <>
        <h2>Turnir Details...</h2>
        <table>
          <thead>
            <tr>
              <th>IDTurnir</th>    
              <th>TournamentName</th> 
            </tr>
          </thead>
          <tbody>
            {turniri.map(tur=>(
              <tr>
                <td key={tur.idTurnir}>{tur.idTurnir}</td>
                <td>{tur.tournamentName}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </>
    )
  }

  export default Turnir;
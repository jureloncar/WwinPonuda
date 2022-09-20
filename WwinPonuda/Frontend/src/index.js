import React from 'react';
import ReactDOM from 'react-dom/client';

class  TurnirComponent extends React.Component{
  constructor(props){
    super(props);

    this.state={
      turnir:[]
    };
  }
  componentDidMount(){
    fetch("https://localhost:7030/api/turnir").then(res=>res.json()).then(
      result=>{
        this.setState({turnir:result}); 
      }
    )
  }

  render() {
    return(
      <div>
        <h2>Turnir Details...</h2>
        <table>
          <thead>
            <tr>
              <th>IDTurnir</th>    
              <th>SportID</th> 
              <th>KategorijaID</th>        
              <th>SuperTurnirID</th> 
              <th>BetradarTournamentID</th> 
              <th>BRSuperTournamentID</th> 
              <th>MinParova</th>
              <th>MaxParova</th> 
              <th>MaxUlog</th> 
              <th>SastavniTurnir</th> 
              <th>TurnirIDSastavni</th> 
              <th>Sink</th> 
              <th>Aktivan</th> 
              <th>RedniBrojIspis</th> 
              <th>RedniBrojFavorit</th> 
              <th>TjednaPonuda</th> 
              <th>GrupaOkladaID</th> 
              <th>TournamentName</th> 
              <th>BetSourceID</th> 
              <th>SourceTournamentID</th> 
              <th>TimeStampUTC</th>
              <th>PrevodNapomena</th>


            </tr>
          </thead>
          <tbody>
            {this.state.turnir.map(tur=>(
              <tr key={tur.IDTurnir}>
                <td>{tur.IDTurnir}</td>
                <td>{tur.KategorijaID}</td>
                <td>{tur.SuperTurnirID}</td>
                <td>{tur.BetradarTournamentID}</td>
                <td>{tur.BRSuperTournamentID}</td>
                <td>{tur.MinParova}</td>
                <td>{tur.MaxParova}</td>
                <td>{tur.MaxUlog}</td>
                <td>{tur.SastavniTurnir}</td>
                <td>{tur.TurnirIDSastavni}</td>
                <td>{tur.Sink}</td>
                <td>{tur.RedniBrojIspis}</td>
                <td>{tur.RedniBrojFavorit}</td>
                <td>{tur.TjednaPonuda}</td>
                <td>{tur.GrupaOkladaID}</td>
                <td>{tur.TournamentName}</td>
                <td>{tur.BetSourceID}</td>
                <td>{tur.SourceTournamentID}</td>
                <td>{tur.TimeStampUTC}</td>
                <td>{tur.PrevodNapomena}</td>


              </tr>
            ))}
          </tbody>
        </table>
      </div>
    )
  }
}

const element=<TurnirComponent></TurnirComponent>
ReactDOM.render(element,document.getElementById("root"));
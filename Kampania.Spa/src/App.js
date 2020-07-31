import React from 'react';
import Nav from "./_components/nav"
import Main from './_components/main'
import Axios from 'axios';

class App extends React.Component {

  onAddClick = () => {
    this.setState({
      Mode: "Add"
    })
  }

  onHomeClick = () => {
    this.setState({
      Mode: "Home"
    })
  }
  onRaportClick = () => {
    Axios.get("https:localhost:5001/api/campaign/raport")
    .then(result => {
      this.setState({
        raport: result.data.raport
      })
    })
    .catch()
    this.setState({
      Mode: "Raport"
    })

  }
  state = {
    Mode: "Home",
    raport: null
  }
  enableEditMode = () => {
    this.setState({Mode:"Edit"})
  }

  render(){
  return (
    <div className="App">
      <Nav onAddClick={this.onAddClick} onHomeClick={this.onHomeClick} onRaportClick = {this.onRaportClick} />
      <Main Mode = {this.state.Mode} raport={this.state.raport}/>
    </div>
  );
  }
}

export default App;

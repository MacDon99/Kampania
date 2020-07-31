import React from 'react'

class nav extends React.Component {

    render(){
return(
<div>
<nav class="navbar navbar-expand-sm bg-dark navbar-dark">
  <a class="navbar-brand" href="#" onClick={this.props.onHomeClick}>Home</a>
  
  <ul class="navbar-nav">
    <li class="nav-item">
      <a class="nav-link" href="#" onClick={this.props.onAddClick}>Add</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" href="#" onClick={this.props.onRaportClick}>Raport</a>
    </li>
  </ul>
</nav>
</div>
)
}
}
export default nav
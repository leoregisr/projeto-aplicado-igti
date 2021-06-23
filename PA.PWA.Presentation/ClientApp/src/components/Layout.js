import React, { Component } from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';

export class Layout extends Component {

  componentDidMount() {
    this.displayName = this.props.title;
  }  

  render () {
    return (
      <div>
        <NavMenu title={this.displayName} />
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}

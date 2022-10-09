import { Container, Nav, Navbar, NavDropdown } from "react-bootstrap";
import Logo from "../../assets/logo.svg"

export function NavbarComponent() {
  return (
    <Navbar bg="dark" variant="dark">
      <Container>
        <Navbar.Brand href="/">
          <img
            src={Logo}
            width="30"
            height="30"
            className="d-inline-block align-top mx-2"
            alt="Hubla challenge logo"
          />
          Hubla Challenge
        </Navbar.Brand>


        <Nav>
          <Nav.Link href="/">
            Sales list
          </Nav.Link>
          <Nav.Link href="/upload">
            Upload sales
          </Nav.Link>
        </Nav>
      </Container>
    </Navbar>
  );
}
import React from 'react'; 
import './Login.css';
import Form from 'react-bootstrap/Form';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';

export const Login: React.FC = () => ( 
    <div className="Login" > 
        <Form>
            <Form.Group as={Row} controlId="formPlaintextUsername">
                <Form.Label column sm="2">
                    Username:
                </Form.Label>
                <Col sm="10">
                    <Form.Control type="text" placeholder="Username" />
                </Col>
            </Form.Group>

            <Form.Group as={Row} controlId="formPlaintextPassword">
                <Form.Label column sm="2">
                    Password:
                </Form.Label>
                <Col sm="10">
                    <Form.Control type="password" placeholder="Password" />
                </Col>
            </Form.Group>
        </Form>
    </div> 
);
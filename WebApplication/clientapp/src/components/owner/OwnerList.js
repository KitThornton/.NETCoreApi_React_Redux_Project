import React, { Component } from 'react';
import { Table, Col, Row } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import Auxiliary from '../../hoc/Auxillary/Auxillary';
import { connect} from "react-redux";
import * as repositoryActions from '../../store/actions/repositoryActions';
import Owner from './Owner';

class OwnerList extends Component {
    componentDidMount() {
        let url = 'api';
        this.props.onGetData(url, {...this.props});
    }
    
    render() {
        let owners = [];
        if (this.props.data && this.props.data.length > 0) {
            owners = this.props.data.map((owner) => {
                return (
                    <Owner key={owner.id} owner={owner} {...this.props} />
                )
            })
        }
        
        return (
            <Auxiliary>
                <Row>
                    <Col>
                        <Link to='/createOwner' >Create Owner</Link>
                    </Col>
                </Row>
                <br />
                <Row>
                    <Col md={12}>
                        <Table responsive striped>
                            <thead>
                            <tr>
                                <th>Name</th>
                                <th>Date of birth</th>
                                <th>Address</th>
                                <th>Details</th>
                                <th>Update</th>
                                <th>Delete</th>
                            </tr>
                            </thead>
                            <tbody>
                            {owners}
                            </tbody>
                        </Table>
                    </Col>
                </Row>
            </Auxiliary>
        )
    }
}

const mapStateToProps = (state) => {
    return {
        data: state.data
    }
}
const mapDispatchToProps = (dispatch) => {
    return {
        onGetData: (url, props) => dispatch(repositoryActions.getData(url, props))
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(OwnerList);
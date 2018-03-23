import React from 'react';

const ProfileModal = props => {

    let profile = props.profile;

    return (
        <div className="modal fade" id="profileModal" role="dialog" aria-labelledby="profileModalLabel" aria-hidden="true">
            <div className="modal-dialog" role="document">
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title" id="profileModalLabel">Profile Form</h5>
                        <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div className="modal-body">
                        <div className="form-row">
                            <div className="form-group col-md-12">
                                <label htmlFor="image" className="col-form-label"><strong>Profile Image URL: </strong></label>
                                <textarea type="textarea" onChange={(e) => props.handleInputChange(e)} name="image" value={profile.image} className="form-control" />
                            </div>
                        </div>
                        <div className="form-row">
                            <div className="form-group col-md-12">
                                <label htmlFor="description" className="col-form-label"><strong>Profile Description: </strong></label>
                                <textarea type="textarea" onChange={(e) => props.handleInputChange(e)} name="description" value={profile.description} className="form-control" />
                            </div>
                        </div>
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="button" onClick={props.submitProfile}  data-toggle="modal" data-target="#profileModal" className="btn btn-info">Submit Profile</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default ProfileModal;
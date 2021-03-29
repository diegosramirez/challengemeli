from marshmallow import fields, Schema
import datetime
from . import db


class ConfigurationModel(db.Model):

    __tablename__ = 'configurations'

    id = db.Column(db.Integer, primary_key=True)
    application_id = db.Column(db.Integer, db.ForeignKey('applications.id'), nullable=False)
    algorithm_id = db.Column(db.Integer, db.ForeignKey('algorithms.id'), nullable=False)
    created_at = db.Column(db.DateTime)
    modified_at = db.Column(db.DateTime)

    def __init__(self, data):
        self.application_id = data.get('application_id')
        self.algorithm_id = data.get('algorithm_id')
        self.created_at = datetime.datetime.utcnow()
        self.modified_at = datetime.datetime.utcnow()

    def save(self):
        db.session.add(self)
        db.session.commit()

    def update(self, data):
        for key, item in data.items():
            setattr(self, key, item)
        self.modified_at = datetime.datetime.utcnow()
        db.session.commit()

    def delete(self):
        db.session.delete(self)
        db.session.commit()

    @staticmethod
    def get_all_configurations():
        return ConfigurationModel.query.all()

    @staticmethod
    def get_configuration_by_id(id):
        return ConfigurationModel.query.get(id)

    def __repr(self):
        return '<id {}>'.format(self.id)


class ConfigurationSchema(Schema):
    id = fields.Int(dump_only=True)
    application_id = fields.Int(required=True)
    algorithm_id = fields.Int(required=True)
    created_at = fields.DateTime(dump_only=True)
    modified_at = fields.DateTime(dump_only=True)

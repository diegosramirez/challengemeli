"""empty message

Revision ID: 0553b161a343
Revises: 47551d3d24de
Create Date: 2021-03-27 23:03:09.317848

"""
from alembic import op
import sqlalchemy as sa


# revision identifiers, used by Alembic.
revision = '0553b161a343'
down_revision = '47551d3d24de'
branch_labels = None
depends_on = None


def upgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.create_table('algorithms',
    sa.Column('id', sa.Integer(), nullable=False),
    sa.Column('name', sa.String(length=128), nullable=False),
    sa.Column('created_at', sa.DateTime(), nullable=True),
    sa.Column('modified_at', sa.DateTime(), nullable=True),
    sa.PrimaryKeyConstraint('id')
    )
    # ### end Alembic commands ###


def downgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.drop_table('algorithms')
    # ### end Alembic commands ###
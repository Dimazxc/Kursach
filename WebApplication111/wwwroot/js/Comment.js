function setup() {
}

var activeState = 'pressed';

class Comment {
    constructor(newComment) {
        this.id = newComment.Id;
        this.comcontainer = document.getElementById('commentsContainer');
        this.mainDiv = createDiv('').addClass('card mb-3').attribute('style', 'width: 640px').id(commentIdHelper + newComment.Id).parent(this.comcontainer);
        this.row = createDiv('').addClass('row g-0').parent(this.mainDiv);
        this.col = createDiv('').addClass('col-md-12 mt-1').parent(this.row);
        this.cardbody = createDiv('').addClass('card-body').parent(this.col);
        this.title = createElement('h2').addClass('companyTitle').html(newComment.Title).parent(this.cardbody);
        this.content = createElement('p').html(newComment.Content).addClass('companyText notranslate').parent(this.cardbody);
        this.tools(newComment.Likes, newComment.Dislikes);
        this.subscribeEvents();
    }

    tools(likes, dislikes) {
        this.butGroup = createDiv().addClass('btn-group float-right').attribute('role', 'group').parent(this.cardbody);
        this.likeDiv = createDiv('').addClass('like').parent(this.butGroup);
        this.dislikeDiv = createDiv('').addClass('dislike').parent(this.butGroup);
        this.likeicon = createElement('i').html(likes).addClass('fa fa-thumbs-up fa-1x').parent(this.likeDiv);
        this.dislikeicon = createElement('i').html(dislikes).addClass('fa fa-thumbs-down fa-1x').parent(this.dislikeDiv);

    }

    subscribeEvents() {
        this.likeicon.elt.addEventListener('click', () => this.postlike(), false);
        this.dislikeicon.elt.addEventListener('click', () => this.postdislike(), false);
    }

    generateRate() {
        this.comRate = {
            id: window.URL.createObjectURL(new Blob([])).substring(31),
            UserId: curruser.id,
        }
    }

    postlike() {
        this.changecommentrating(this.likeDiv, this.dislikeDiv, true, this.likeicon, this.dislikeicon );
    }

    postdislike() {
        this.changecommentrating(this.dislikeDiv, this.likeDiv, false, this.dislikeicon, this.likeicon);
    }


    changecommentrating(divSend, divRemove, rateState, icon, iconRemove) {
        if (curruser == null) $('#logregmodal').modal();
            else {
            this.generateRate(),
            this.comRate.islike = rateState;
            if (!divSend.class().includes(activeState)) {
                $.post('/CommentRating/AddCommentRating', { 'commentRating': this.comRate, 'commentId': this.id, 'userId': curruser.id }, function () { });
                if (divRemove.class().includes(activeState)) iconRemove.html(parseInt(iconRemove.html()) - 1);
                icon.html(parseInt(icon.html()) + 1);
                divSend.addClass('pressed')
                divRemove.removeClass('pressed')
            }
            else {
                icon.html(parseInt(icon.html()) - 1);
                divSend.removeClass('pressed')
                $.post('/CommentRating/RemoveCommentRating', { 'userId': curruser.id, 'commentId': this.id }, function () { });
            }
        }
    }
}


function sendComment(newComment) {
    let comment = new Comment(newComment);
}